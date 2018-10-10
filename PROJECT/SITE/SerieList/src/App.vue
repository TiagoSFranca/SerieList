<template>
  <v-app id="inspire">
    <v-navigation-drawer :clipped="$vuetify.breakpoint.lgAndUp" v-model="drawer" fixed app>
      <side-bar/>
    </v-navigation-drawer>
    <toolbar />
    <v-content>
      <v-container fluid fill-height>
        <v-layout justify-center >
          <progress-circular/>
          <progress-bar/>
          <router-view />
        </v-layout>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
import Toolbar from '@/components/General/Toolbar'
import ProgressBar from '@/components/General/ProgressBar'
import SideBar from '@/components/General/SideBar'
import StoreGeneralConstants from '@/store/constants/general'
import ProgressCircular from '@/components/General/ProgressCircular'
import { mapGetters } from 'vuex'
export default {
  components: {
    ProgressCircular,
    Toolbar,
    SideBar,
    ProgressBar
  },
  props: {
    source: String
  },
  computed: {
    ...mapGetters({
      drawer: StoreGeneralConstants.GETTERS.SHOW_DRAWER
    })
  }
}
</script>

<style>
.img-logo{
  max-height: 36px;
  width: auto !important;
}
.no-display{
  display: none;
}
</style>
