<template>
    <div>
        <clickCountButton v-bind:initialCounter="10" />
        <clickCountButton v-bind:initialCounter="20" />
    </div>
</template>

<script>
    import clickCountButton from "@/views/ClickCountButton.vue"
    
    export default {
        components : {
            clickCountButton
        },
        data() {
            return {
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
