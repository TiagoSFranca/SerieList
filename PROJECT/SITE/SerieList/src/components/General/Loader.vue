<template>
    <v-dialog
      v-model="dialog"
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
export default {
  data () {
    return {
      dialog: false
    }
  },
  methods: {
    showLoader (value) {
      this.dialog = value
    }
  }
}
</script>
