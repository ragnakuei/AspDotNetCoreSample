<template>
    <div class="page-container">
        <md-app md-waterfall md-mode="fixed-last">
            <md-app-toolbar class="md-large md-dense md-primary">
                <div class="md-toolbar-row">
                    <div class="md-toolbar-section-start">
                        <md-button class="md-icon-button" @click="menuVisible = !menuVisible">
                            <md-icon>menu</md-icon>
                        </md-button>

                        <span class="md-title">My Title</span>
                    </div>

                    <div class="md-toolbar-section-end">
                        <md-button class="md-icon-button">
                            <md-icon>more_vert</md-icon>
                        </md-button>
                    </div>
                </div>

                <div class="md-toolbar-row">
                    <md-tabs class="md-primary">
                        <md-tab id="tab-home" md-label="Home" to="/"></md-tab>
                        <md-tab id="tab-pages" md-label="Order" to="/order"></md-tab>
                    </md-tabs>
                </div>
            </md-app-toolbar>
            <md-app-drawer :md-active.sync="menuVisible">
                <md-toolbar class="md-transparent" md-elevation="0">Navigation</md-toolbar>

                <md-list>
                    <md-list-item>
                        <md-icon>move_to_inbox</md-icon>
                        <span class="md-list-item-text">Inbox</span>
                    </md-list-item>

                    <md-list-item>
                        <md-icon>send</md-icon>
                        <span class="md-list-item-text">Sent Mail</span>
                    </md-list-item>

                    <md-list-item>
                        <md-icon>delete</md-icon>
                        <span class="md-list-item-text">Trash</span>
                    </md-list-item>

                    <md-list-item>
                        <md-icon>error</md-icon>
                        <span class="md-list-item-text">Spam</span>
                    </md-list-item>
                </md-list>
            </md-app-drawer>
            <md-app-content>
                <router-view/>
            </md-app-content>
        </md-app>
    </div>
</template>

<style lang="scss" scoped>
    .md-app {
        /*max-height: 400px;*/
        max-height: calc(100vh);
        border: 1px solid rgba(#000, .12);
    }

    // Demo purposes only
    .md-drawer {
        width: 230px;
        max-width: calc(100vw - 125px);
    }
</style>

<script>
    import OrderVue from "./views/Order.vue";

    export default {
        name: 'LastRowFixed',
        comments: {
            Order: OrderVue,
        },
        data: () => ({
            menuVisible: false
        })
    }
</script>