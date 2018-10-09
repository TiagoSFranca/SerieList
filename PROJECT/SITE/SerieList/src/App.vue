<template>
  <v-app id="inspire">
    <v-navigation-drawer :clipped="$vuetify.breakpoint.lgAndUp" v-model="drawer" fixed app>
      <side-bar/>
    </v-navigation-drawer>
    <toolbar />
    <v-content>
      <v-container fluid fill-height>
        <v-layout justify-center align-center>
          <router-view/>
        </v-layout>
      </v-container>
    </v-content>
    <!-- <v-btn
      fab
      bottom
      right
      class="primary"
      fixed
      @click="dialog = !dialog"
    >
      <v-icon>add</v-icon>
    </v-btn> -->
    <!-- <div class="text-xs-right" fixed right botton>
      <v-btn fab dark color="primary">
        <v-icon dark>add</v-icon>
      </v-btn>
      <v-btn fab dark color="primary">
        <v-icon dark>filter_list</v-icon>
      </v-btn>
    </div>
    <v-dialog v-model="dialog" width="800px">
      <v-card>
        <v-card-title
          class="grey lighten-4 py-4 title"
        >
          Create contact
        </v-card-title>
        <v-container grid-list-sm class="pa-4">
          <v-layout row wrap>
            <v-flex xs12 align-center justify-space-between>
              <v-layout align-center>
                <v-avatar size="40px" class="mr-3">
                  <img
                    src="//ssl.gstatic.com/s2/oz/images/sge/grey_silhouette.png"
                    alt=""
                  >
                </v-avatar>
                <v-text-field
                  placeholder="Name"
                ></v-text-field>
              </v-layout>
            </v-flex>
            <v-flex xs6>
              <v-text-field
                prepend-icon="business"
                placeholder="Company"
              ></v-text-field>
            </v-flex>
            <v-flex xs6>
              <v-text-field
                placeholder="Job title"
              ></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field
                prepend-icon="mail"
                placeholder="Email"
              ></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field
                type="tel"
                prepend-icon="phone"
                placeholder="(000) 000 - 0000"
                mask="phone"
              ></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field
                prepend-icon="notes"
                placeholder="Notes"
              ></v-text-field>
            </v-flex>
          </v-layout>
        </v-container>
        <v-card-actions>
          <v-btn flat color="primary">More</v-btn>
          <v-spacer></v-spacer>
          <v-btn flat color="primary" @click="dialog = false">Cancel</v-btn>
          <v-btn flat @click="dialog = false">Save</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog> -->
  </v-app>
</template>

<script>
import Toolbar from '@/components/General/Toolbar'
import Loader from '@/components/General/Loader'
import SideBar from '@/components/General/SideBar'
import StoreGeneralConstants from '@/store/constants/general'
import { mapGetters } from 'vuex'
export default {
  components: {
    Loader,
    Toolbar,
    SideBar
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
