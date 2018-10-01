<template>
    <v-toolbar app fixed clipped-left class="primary">
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <router-link to="/">
      <img src="@/assets/logo.png" class="img-logo">
      </router-link>
      <v-toolbar-title>
        {{pageTitle}}
        </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-text-field dark append-icon="search" clearable></v-text-field>
        <v-divider vertical></v-divider>
        <template v-if="!logged">
            <v-btn flat>Registrar</v-btn>
            <v-divider vertical></v-divider>
            <v-btn flat to="/Login">Entrar</v-btn>
        </template>
        <template v-else>
            <v-btn flat to="/Logout">Sair</v-btn>
        </template>
      </v-toolbar-items>
    </v-toolbar>
</template>

<script>
import AuthHelper from '@/helpers/auth'
export default {
  data: () => ({
    drawer: false,
    pageTitle: 'Início',
    logged: false
  }),
  props: {
    source: String
  },
  methods: {
    updatePageTitle (title) {
      this.pageTitle = title
    }
  },
  mounted: function () {
    if (AuthHelper.getToken()) {
      this.logged = true
    }
  }
}
</script>
