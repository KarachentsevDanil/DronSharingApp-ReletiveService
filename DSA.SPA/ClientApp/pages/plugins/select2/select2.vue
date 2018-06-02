<template>
    <select></select>
</template>

<script>
    import select2 from "select2";

    export default {
        props: {
            configuration: {
                type: Object
            },
            options: {
                type: Array
            },
            value: {
                
            }
        },
        data() {
            return {

            };
        },
        mounted: function () {
            var vm = this;
            var element = $(this.$el);

            this.configuration.data = this.options;
            
            element
                // init select2
                .select2(this.configuration)
                .val(this.value)
                .trigger('change')
                // emit event on change.
                .on('change', function () {
                    vm.$emit('input', element.val())
                });
        },
        watch: {
            // value: function (value) {
            //     // update value
            //     $(this.$el)
            //         .val(value)
            //         .trigger('change')
            // },
            options: function (options) {
                // update options
                this.configuration.data = this.options;
                $(this.$el).empty().select2(this.configuration);
            }
        },
        destroyed: function () {
            $(this.$el).off().select2('destroy');
        }
    };
</script>
