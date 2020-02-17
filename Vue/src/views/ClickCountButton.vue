<template>
    <button @click="count++">You clicked me {{ count }} times.</button>
</template>

<script>
    export default {
        name: "clickCountButton",
        props: ['initialCounter'],
        data() {
            return {
                count : this.initialCounter
            }
        }
    }
</script>