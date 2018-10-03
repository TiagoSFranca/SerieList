<template>
    <v-dialog
      v-model="showLoader"
      persistent
      width="300"
    >
      <v-card
        color="primary"
        dark
      >
        <v-card-text>
          <v-progress-linear
            indeterminate
            color="info"
            class="mb-1"
          ></v-progress-linear>
        </v-card-text>
      </v-card>
    </v-dialog>
</template>
<script>
import { mapGetters } from 'vuex'
import StoreGeneralConstants from '@/store/constants/general'
export default {
  data () {
    return {
      dialog: false
    }
  },
  computed: {
    ...mapGetters({
      showLoader: StoreGeneralConstants.GETTERS.SHOW_LOADER
    })
  }
}
</script>
