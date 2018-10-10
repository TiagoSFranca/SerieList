<template>
    <v-dialog
      v-model="showProgressBar"
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
    }
  },
  computed: {
    ...mapGetters({
      showProgressBar: StoreGeneralConstants.GETTERS.SHOW_PROGRESS_BAR
    })
  }
}
</script>
