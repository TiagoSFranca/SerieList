<template>
<div>
    <v-toolbar app fixed clipped-left class="primary">
      <v-toolbar-side-icon @click="showMenu"></v-toolbar-side-icon>
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
import LogoutModal from '@/components/General/LogoutModal'
import { mapGetters, mapActions } from 'vuex'
import StoreGeneralConstants from '@/store/constants/general'
export default {
  data: () => ({
    logged: false
  }),
  props: {
    source: String
  },
  components: {
    LogoutModal
  },
  computed: {
    ...mapGetters({
      pageTitle: StoreGeneralConstants.GETTERS.PAGE_TITLE,
      showDrawer: StoreGeneralConstants.GETTERS.SHOW_DRAWER
    })
  },
  methods: {
    ...mapActions({
      changeShowDrawer: StoreGeneralConstants.ACTIONS.CHANGE_SHOW_DRAWER
    }),
    showMenu () {
      this.changeShowDrawer(!this.showDrawer)
    }
  },
  mounted: function () {
    if (this.token) {
      this.logged = true
    }
  }
}
</script>
