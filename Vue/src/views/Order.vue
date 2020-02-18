<template>
    <div>
        <checkedButton v-for="value in buttons"
                       ref="checkedButtons"
                       v-bind:id="value.id" 
                       v-bind:initialChecked="value.isChecked" />
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
