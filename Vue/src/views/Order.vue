<template>
    <div>
        <checkedButton v-bind:id="1" 
                       v-bind:initialChecked="false" 
                       v-on:onButtonClick="checkedButtonClick" />
        
        <checkedButton v-bind:id="2" 
                       v-bind:initialChecked="true" 
                       v-on:onButtonClick="checkedButtonClick" />
    </div>
</template>

<script>
    import checkedButton from "@/views/CheckedButton.vue"
    
    export default {
        components : {
            checkedButton
        },
        data() {
            return {
            }
        },
        methods : {
            checkedButtonClick : function(target) {
                console.log(target);
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
