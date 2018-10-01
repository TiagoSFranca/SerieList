<template>
<div>
    <v-toolbar app fixed clipped-left class="primary">
      <v-toolbar-side-icon @click.stop="showDrawer"></v-toolbar-side-icon>
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
            <v-btn flat @click="showModal">Sair</v-btn>
        </template>
      </v-toolbar-items>
    </v-toolbar>
    <logout-modal ref="logoutModal"/>
</div>
</template>

<script>
import AuthHelper from '@/helpers/auth'
import LogoutModal from '@/components/General/LogoutModal'
export default {
  data: () => ({
    drawer: false,
    pageTitle: 'Início',
    logged: false
  }),
  props: {
    source: String
  },
  components: {
    LogoutModal
  },
  methods: {
    updatePageTitle (title) {
      this.pageTitle = title
    },
    showModal () {
      this.$refs.logoutModal.showModal(true)
    },
    showDrawer () {
      this.drawer = !this.drawer
      this.$emit('on-show-drawer', this.drawer)
    }
  },
  mounted: function () {
    if (AuthHelper.getToken()) {
      this.logged = true
    }
  }
}
</script>
