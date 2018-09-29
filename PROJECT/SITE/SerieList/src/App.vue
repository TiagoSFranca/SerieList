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
    <v-toolbar app fixed clipped-left class="primary">
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <router-link to="/">
      <img src="./assets/logo.png" class="img-logo">
      </router-link>
      <v-toolbar-title>
        {{pageTitle}}
        </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-text-field dark append-icon="search" clearable></v-text-field>
        <v-divider vertical></v-divider>
        <v-btn flat>Registrar</v-btn>
        <v-divider vertical></v-divider>
        <v-btn flat to="/Login">Entrar</v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-layout>
          <v-flex shrink xs12 sm12 md12>
            <router-view @on-page-title-change="updatePageTitle"/>
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
export default {
  data: () => ({
    drawer: false,
    pageTitle: 'Início'
  }),
  props: {
    source: String
  },
  methods: {
    updatePageTitle (title) {
      this.pageTitle = title
    }
  }
}
</script>

<style>
.img-logo{
  max-height: 38px;
}
</style>
