<template>
    <button @click="onClick">Checked : {{ isChecked }}</button>
</template>

<script>
    export default {
        name: "checkedButton",
        props: {
            initialChecked : Boolean,
            itemId: Number,
        },
        data() {
            return {
                isChecked : this.initialChecked
            }
        },
        methods : {
            onClick : function(t) {
                // t : MouseEvent
                // console.log(t);
                
                this.isChecked = !this.isChecked;
                
                this.$emit("onButtonClick", {
                    id: this.itemId,
                    isChecked: this.isChecked,
                });
            }
        }
    }
</script>