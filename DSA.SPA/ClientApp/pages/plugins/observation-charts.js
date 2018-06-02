import * as moment from 'moment';
import d3 from 'd3';
import d3Tip from 'd3-tip';
d3.tip = d3Tip;


export function renderTwoLineGraph(element, observations, rangeType, chartHeight, lineColor, lineColor2, pathColor, pointerLineColor, pointerBgColor, pointerLineColor2, pointerBgColor2) {
    var dataset = {};
    if (rangeType !== 'yearlyObservations') {
        var dataset = observations.map((item) => {
            return {
                date: moment.default(item.RecordedDate).format('MM/DD/YY'),
                alpha: item.DiastolicValue,
                beta: item.SystolicValue
            };
        });
    } else {
        var dataset = observations.map((item) => {
            return {
                date: moment.default(item.RecordedDate + (new Date()).getFullYear()).format('MM/DD/YY'),
                alpha: item.DiastolicValue,
                beta: item.SystolicValue
            };
        });
    }

    // Main variables
    var d3Container = d3.select(element),
        margin = { top: 0, right: 0, bottom: 0, left: 0 },
        width = d3Container.node().getBoundingClientRect().width - margin.left - margin.right,
        height = chartHeight - margin.top - margin.bottom,
        padding = 20;

    // Format date
    var parseDate = d3.time.format("%m/%d/%y").parse,
        formatDate = d3.time.format("%a, %B %e");


    // Add tooltip
    // ------------------------------

    var tooltip = d3.tip()
        .attr('class', 'd3-tip')
        .html(function (d) {
            return "<ul class='list-unstyled'>" +
                "<li>" + "<div class='text-size-base'><i class='icon-check2 position-left'></i>" + formatDate(d.date) + "</div>" + "</li>" +
                "<li>" + "Pressure: &nbsp;" + "<span class='text-semibold pull-right'>" + d.beta + "/" + d.alpha + "</span>" + "</li>" +
                "</ul>";
        });


    // Create chart
    // ------------------------------

    // Add svg element
    var container = d3Container.append('svg');

    // Add SVG group
    var svg = container
        .attr('width', width + margin.left + margin.right)
        .attr('height', height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")")
        .call(tooltip);


    // Load data
    // ------------------------------
    var index = 0;
    dataset.forEach(function (d) {
        d.index = index++;
        d.date = new Date(d.date);
        d.alpha = +d.alpha;
        d.beta = +d.beta;
    });


    // Construct scales
    // ------------------------------

    // Horizontal
    var x = d3.time.scale()
        .range([padding, width - padding]);

    // Vertical
    var y = d3.scale.linear()
        .range([height, 5]);


    // Set input domains
    // ------------------------------

    //// Horizontal
    x.domain(d3.extent(dataset, function (d) {
        //return d.date;
        return d.index;
    }));

    //// Horizontal
    //x.domain(d3.range(0, dataset.length));

    // Vertical
    y.domain([0, d3.max(dataset, function (d) {
        return Math.max(d.alpha, d.beta);
    })]);

    // Line
    var line = d3.svg.line()
        .x(function (d) { return x(d.index); })
        .y(function (d) { return y(d.alpha); });

    var line2 = d3.svg.line()
        .x(function (d) { return x(d.index); })
        .y(function (d) { return y(d.beta); });

    // Add clip path
    var clip = svg.append("defs")
        .append("clipPath")
        .attr("id", "clip-line-small");

    // Add clip shape
    var clipRect = clip.append("rect")
        .attr('class', 'clip')
        .attr("width", 0)
        .attr("height", height);

    // Animate mask
    clipRect
        .transition()
        .duration(1000)
        .ease('linear')
        .attr("width", width);


    // Line
    // ------------------------------

    // Path
    var path = svg.append('path')
        .attr({
            'd': line(dataset),
            "clip-path": "url(#clip-line-small)",
            'class': 'alpha d3-line d3-line-medium'
        })
        .style('stroke', lineColor);
    var path2 = svg.append('path')
        .attr({
            'd': line2(dataset),
            "clip-path": "url(#clip-line-small)",
            'class': 'beta d3-line d3-line-medium'
        })
        .style('stroke', lineColor2);

    // Animate path
    svg.select('.line-tickets')
        .transition()
        .duration(1000)
        .ease('linear');


    // Add vertical guide lines
    // ------------------------------

    // Bind data
    var guide = svg.append('g')
        .selectAll('.d3-line-guides-group')
        .data(dataset);

    // Append lines
    guide
        .enter()
        .append('line')
        .attr('class', 'd3-line-guides')
        .attr('x1', function (d, i) {
            return x(d.index);
        })
        .attr('y1', function (d, i) {
            return height;
        })
        .attr('x2', function (d, i) {
            return x(d.index);
        })
        .attr('y2', function (d, i) {
            return height;
        })
        .style('stroke', pathColor)
        .style('stroke-dasharray', '4,2')
        .style('shape-rendering', 'crispEdges');

    // Animate guide lines
    guide
        .transition()
        .duration(1000)
        .delay(function (d, i) { return i * 150; })
        .attr('y2', function (d, i) {
            return y(d.alpha);
        });


    // Alpha app points
    // ------------------------------

    // Add points
    var points = svg.insert('g')
        .selectAll('.d3-line-circle')
        .data(dataset)
        .enter()
        .append('circle')
        .attr('class', 'd3-line-circle d3-line-circle-medium')
        .attr("cx", line.x())
        .attr("cy", line.y())
        .attr("r", 3)
        .style({
            'stroke': pointerLineColor,
            'fill': pointerBgColor
        });

    var points2 = svg.insert('g')
        .selectAll('.d3-line-circle')
        .data(dataset)
        .enter()
        .append('circle')
        .attr('class', 'd3-line-circle d3-line-circle-medium')
        .attr("cx", line2.x())
        .attr("cy", line2.y())
        .attr("r", 3)
        .style({
            'stroke': pointerLineColor2,
            'fill': pointerBgColor2
        });

    // Animate points on page load
    points
        .style('opacity', 0)
        .transition()
        .duration(250)
        .ease('linear')
        .delay(1000)
        .style('opacity', 1);

    // Add user interaction
    points
        .on("mouseover", function (d) {
            tooltip.offset([-10, 0]).show(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 4);
        })

        // Hide tooltip
        .on("mouseout", function (d) {
            tooltip.hide(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 3);
        });

    // Change tooltip direction of first point
    d3.select(points[0][0])
        .on("mouseover", function (d) {
            tooltip.offset([0, 10]).direction('e').show(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 4);
        })
        .on("mouseout", function (d) {
            tooltip.direction('n').hide(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 3);
        });

    // Change tooltip direction of last point
    d3.select(points[0][points.size() - 1])
        .on("mouseover", function (d) {
            tooltip.offset([0, -10]).direction('w').show(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 4);
        })
        .on("mouseout", function (d) {
            tooltip.direction('n').hide(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 3);
        });


    points2.on("mouseover", function (d) {
        tooltip.offset([-10, 0]).show(d);

        // Animate circle radius
        d3.select(this).transition().duration(250).attr('r', 4);
    })

        // Hide tooltip
        .on("mouseout", function (d) {
            tooltip.hide(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 3);
        });

    // Change tooltip direction of first point
    d3.select(points2[0][0])
        .on("mouseover", function (d) {
            tooltip.offset([0, 10]).direction('e').show(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 4);
        })
        .on("mouseout", function (d) {
            tooltip.direction('n').hide(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 3);
        });

    // Change tooltip direction of last point
    d3.select(points2[0][points.size() - 1])
        .on("mouseover", function (d) {
            tooltip.offset([0, -10]).direction('w').show(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 4);
        })
        .on("mouseout", function (d) {
            tooltip.direction('n').hide(d);

            // Animate circle radius
            d3.select(this).transition().duration(250).attr('r', 3);
        });


    // Call function on window resize
    window.addEventListener('resize', lineChartResize);
    // Call function on sidebar width change
    $(document).on('click', '.sidebar-control', lineChartResize);
    // Resize function
    //
    // Since D3 doesn't support SVG resize by default,
    // we need to manually specify parts of the graph that need to
    // be updated on window resize
    function lineChartResize() {

        // Layout variables
        width = d3Container.node().getBoundingClientRect().width - margin.left - margin.right;

        // Main svg width
        container.attr("width", width + margin.left + margin.right);

        // Width of appended group
        svg.attr("width", width + margin.left + margin.right);

        // Horizontal range
        x.range([padding, width - padding]);

        // Mask
        clipRect.attr("width", width);

        // Line path
        path.attr("d", line(dataset));
        path2.attr("d", line2(dataset));

        // Circles
        svg.selectAll('.d3-line-circle').attr("cx", line.x());

        // Guide lines
        svg.selectAll('.d3-line-guides')
            .attr('x1', function (d, i) {
                return x(d.index);
            })
            .attr('x2', function (d, i) {
                return x(d.index);
            });
    }
}

export function renderAreaChart(element, observations, rangeType, chartHeight, color) {

    var dataset = {};

    if (rangeType !== 'yearlyObservations') {
        var dataset = observations.map((item) => {
            return {
                date: moment.default(item.RecordedDate).format('MM/DD/YY'),
                value: item.Value
            };
        });
    } else {
        var dataset = observations.map((item) => {
            return {
                date: moment.default(item.RecordedDate + (new Date()).getFullYear()).format('MM/DD/YY'),
                value: item.Value
            };
        });
    }

    // Define main variables
    var d3Container = d3.select(element),
        margin = { top: 0, right: 0, bottom: 0, left: 0 },
        width = d3Container.node().getBoundingClientRect().width - margin.left - margin.right,
        height = chartHeight - margin.top - margin.bottom;

    // Date and time format
    var parseDate = d3.time.format('%Y-%m-%d').parse;

    // Container
    var container = d3Container.append('svg');

    // SVG element
    var svg = container
        .attr('width', width + margin.left + margin.right)
        .attr('height', height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");


    // Construct chart layout
    // ------------------------------

    // Area
    var area = d3.svg.area()
        .x(function (d) { return x(d.index); })
        .y0(height)
        .y1(function (d) { return y(d.value); })
        .interpolate('monotone');


    // Construct scales
    // ------------------------------

    // Horizontal
    var x = d3.time.scale().range([0, width]);

    // Vertical
    var y = d3.scale.linear().range([height, 0]);

    // Pull out values
    var index = 0;
    dataset.forEach(function (d) {
        d.index = index++;
        d.date = new Date(d.date);
        d.value = +d.value;
    });

    // Reset start data for animation
    var startData = dataset.map(function (datum) {
        return {
            date: datum.date,
            value: 0
        };
    });


    // Set input domains
    // ------------------------------

    // Horizontal
    x.domain(d3.extent(dataset, function (d, i)
    {
        //return d.date;
        return d.index;
    }));

    var minY = d3.min(dataset, function (d) { return d.value; });
    var maxY = d3.max(dataset, function (d) { return d.value; });
    // Vertical
    // Incease lower domain boundary on a quarter of value range
    y.domain([minY - ((maxY - minY) / 4), maxY]);

    // Add area path
    svg.append("path")
        .datum(dataset)
        .attr("class", "d3-area")
        .style('fill', color)
        .attr("d", area)
        .transition() // begin animation
        .duration(1000)
        .attrTween('d', function () {
            var interpolator = d3.interpolateArray(startData, dataset);
            return function (t) {
                return area(interpolator(t));
            };
        });


    // Resize chart
    // ------------------------------

    // Call function on window resize
    window.addEventListener('resize', messagesAreaResize);
    $(document).on('click', '.sidebar-control', messagesAreaResize);
    //// Call function on sidebar width change
    //$(document).on('click', '.sidebar-control', messagesAreaResize);

    // Resize function
    //
    // Since D3 doesn't support SVG resize by default,
    // we need to manually specify parts of the graph that need to
    // be updated on window resize
    function messagesAreaResize() {

        // Layout variables
        width = d3Container.node().getBoundingClientRect().width - margin.left - margin.right;
        // Layout
        // -------------------------

        // Main svg width
        container.attr("width", width + margin.left + margin.right);

        // Width of appended group
        svg.attr("width", width + margin.left + margin.right);

        // Horizontal range
        x.range([0, width]);


        // Chart elements
        // -------------------------

        // Area path
        svg.selectAll('.d3-area').datum(dataset).attr("d", area);
    }
}

export function renderBarChart(element, observations, barQty, height, animate, easing, duration, delay, color, unit) {
    var bardata = observations.map((item) => {
        return item.Value;
    });

    // Main variables
    var d3Container = d3.select(element),
        width = d3Container.node().getBoundingClientRect().width;
    // Construct scales
    // Horizontal
    var x = d3.scale.ordinal()
        .rangeBands([0, width], 0.3);
    // Vertical
    var y = d3.scale.linear()
        .range([0, height]);

    // Horizontal
    x.domain(d3.range(0, bardata.length));

    // Vertical
    y.domain([0, d3.max(bardata)]);
    // Create chart
    // ------------------------------
    // Add svg element
    var container = d3Container.append('svg');

    // Add SVG group
    var svg = container
        .attr('width', width)
        .attr('height', height)
        .append('g');

    //
    // Append chart elements
    //

    // Bars
    var bars = svg.selectAll('rect')
        .data(bardata)
        .enter()
        .append('rect')
        .attr('class', 'd3-random-bars')
        .attr('width', x.rangeBand())
        .attr('x',
        function (d, i) {
            return x(i);
        })
        .style('fill', color);


    // Tooltip
    // ------------------------------

    //// Initiate
    var tip = d3.tip()
        .attr('class', 'd3-tip')
        .offset([-10, 0]);

    // Show and hide
    bars.call(tip)
        .on('mouseover', tip.show)
        .on('mouseout', tip.hide);


    tip.html(function (d, i) {
        return "<div class='text-center'>" +
            "<h6 class='no-margin'>" +
            d +
            " " +
            unit +
            "</h6>" +
            "</div>";
    });

    // Bar loading animation
    if (animate) {
        withAnimation();
    } else {
        withoutAnimation();
    }

    // Animate on load
    function withAnimation() {
        bars.attr('height', 0)
            .attr('y', height)
            .transition()
            .attr('height',
            function (d) {
                return y(d);
            })
            .attr('y',
            function (d) {
                return height - y(d);
            })
            .delay(function (d, i) {
                return i * delay;
            })
            .duration(duration)
            .ease(easing);
    }

    // Load without animateion
    function withoutAnimation() {
        bars
            .attr('height',
            function (d) {
                return y(d);
            })
            .attr('y',
            function (d) {
                return height - y(d);
            });
    }

    // Resize chart
    window.addEventListener('resize', barsResize);
    $(document).on('click', '.sidebar-control', barsResize);
    // Since D3 doesn't support SVG resize by default,
    // we need to manually specify parts of the graph that need to
    // be updated on window resize
    function barsResize() {
        // Layout variables
        width = d3Container.node().getBoundingClientRect().width;

        // Main svg width
        container.attr("width", width);

        // Width of appended group
        svg.attr("width", width);

        // Horizontal range
        x.rangeBands([0, width], 0.3);

        // Chart elements
        svg.selectAll('.d3-random-bars')
            .attr('width', x.rangeBand())
            .attr('x',
            function (d, i) {
                return x(i);
            });
    }
}
