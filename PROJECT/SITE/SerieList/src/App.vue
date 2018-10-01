<template>
  <v-app id="inspire" dark>
    <v-navigation-drawer v-model="drawer" clipped fixed app class="primary">
      <v-list dense class="accent">
        <v-list-tile :to="{name:'HomeIndex'}">
          <v-list-tile-action>
            <v-icon>home</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Início</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
        <v-list-tile :to="{name:'ProductIndex'}">
          <v-list-tile-action>
            <v-icon>settings</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>Produtos</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
    <toolbar />
    <v-content>
      <v-container fluid fill-height>
        <v-layout>
          <v-flex shrink xs12 sm12 md12>
            <loader ref="loader"/>
            <router-view @on-page-title-change="updatePageTitle" @on-show-loader="showLoader"/>
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
    <v-footer app fixed>
      <v-flex py-3 text-xs-center white--text xs12>
        &copy;2018 — <strong>Vuetify</strong>
      </v-flex>
    </v-footer>
  </v-app>
</template>

<script>
import Loader from '@/components/General/Loader'
import Toolbar from '@/components/General/Toolbar'
export default {
  data: () => ({
    drawer: false
  }),
  props: {
    source: String
  },
  components: {
    Loader,
    Toolbar
  },
  methods: {
    updatePageTitle (title) {
      this.$refs.Toolbar.updatePageTitle(title)
    },
    showLoader (value) {
      this.$refs.loader.showLoader(value)
    }
  }
}
</script>

<style>
.img-logo{
  max-height: 38px;
}
</style>
