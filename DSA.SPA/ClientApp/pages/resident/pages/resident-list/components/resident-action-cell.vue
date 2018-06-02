<template>
    <div class="text-center">
        <ul class="icons-list">
            <li class="dropdown dropup">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    <i class="icon-menu7"></i>
                </a>
                <ul class="dropdown-menu dropdown-menu-right">
                    <li>
                        <router-link :to="'/resident-details/'+row.ResidentId" class="text-muted">
                            <i class="icon-pencil"></i> Details
                        </router-link>
                    </li>
                    <li>
                        <a href="#" @click="addDoctor">
                            <i class="icon-plus"></i>
                            Add Doctor
                        </a>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
  props: ["row", "xprops"],
  methods: {
    addDoctor() {
        this.xprops.selectedResident = this.row;
        console.log(this.xprops.selectedResident);
        $('#addResidentDoctor').modal('show');
    }
  }
};
</script>