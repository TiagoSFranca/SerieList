<template>
  <div class="progress">
    <v-progress-circular
      v-if="showProgressCircular"
      :size="100"
      :width="7"
      color="primary"
      indeterminate
    ></v-progress-circular>
  </div>
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
      showProgressCircular: StoreGeneralConstants.GETTERS.SHOW_PROGRESS_CIRCULAR
    })
  }
}
</script>

<style scoped>
  .v-progress-circular {
    margin: 1rem
  }
  .progress{
    align-items: center;
    display: flex;
    height: 100%;
    justify-content: center;
    left: 0;
    pointer-events: none;
    position: fixed;
    top: 0;
    transition: 0.2s cubic-bezier(0.25, 0.8, 0.25, 1);
    width: 100%;
    z-index: 6;
    outline: none;
  }
</style>
