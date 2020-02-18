<template>
    <div>
        <checkedButton v-for="value in buttons"
                       v-bind:id="'checkedButton'+value.id"
                       ref="checkedButtons"
                       v-bind:itemId="value.id" 
                       v-bind:initialChecked="value.isChecked" 
                       v-on:onButtonClick="checkedButtonClick" />
    </div>
</template>

<script>
    import checkedButton from "@/views/CheckedButton.vue"
    
    export default {
        components : {
            checkedButton
        },
        props:[
        ],
        data() {
            return {
                buttons : [
                    {id : 1, isChecked : false},
                    {id : 2, isChecked : true},
                    {id : 3, isChecked : false},
                ]
            }
        },
        methods : {
            checkedButtonClick : function(target) {
                console.log(target);

                // 取出 this.$refs 的資料
                console.log(this.$refs["checkedButtons"]);

                // 一次取出指定 component 內所有資料，省去儲存子類狀態
                this.$refs["checkedButtons"].forEach(element => {
                    console.log(element.itemId);                    
                    console.log(element.isChecked);                    
                });
            }
        }
    } 
</script>


<!--<template>-->
<!--    <div>-->
<!--        <p>{{ this.title }}</p>-->
<!--        <div>{{ firstName + ' ' + lastName }}</div>-->
<!--        &lt;!&ndash;        <div>{{ fullName() }}</div>&ndash;&gt;-->
<!--    </div>-->
<!--</template>-->

<!--<script>-->
<!--    // export default {-->
<!--    //     name: 'order',-->
<!--    //     components: {},-->
<!--    //     data() {-->
<!--    //         return {-->
<!--    //             firstName: 'Foo',-->
<!--    //             lastName: 'Bar',-->
<!--    //         }-->
<!--    //     },-->
<!--    //     methods : {-->
<!--    //         fullName() {-->
<!--    //             return this.firstName + ' ' + this.lastName;-->
<!--    //         }-->
<!--    //     }-->
<!--    // }-->

<!--    export default {-->
<!--        props: {-->
<!--            title : 'Order',-->
<!--            firstName: 'Foo',-->
<!--            lastName: 'Bar',-->
<!--        },-->
<!--        methods : {-->
<!--            -->
<!--        },-->
<!--        setup() {-->
<!--            -->
<!--            console.log(this.title);-->
<!--            -->
<!--            function fullName() {-->
<!--                return firstName + ' ' + lastName;-->
<!--            }-->
<!--        }-->
<!--    }-->

<!--</script>-->
