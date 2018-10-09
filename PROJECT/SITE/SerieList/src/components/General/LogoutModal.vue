<template v-if="dialog">
  <v-layout row justify-center class="no-display">
    <v-dialog v-model="dialog" max-width="320">
      <v-card>
        <v-card-title class="headline">Sair</v-card-title>
        <v-card-text class="title">
          Deseja realmente sair?
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn class="error" flat="flat" outline @click="closeModal">
            Cancelar
          </v-btn>

          <v-btn class="primary" flat="flat" outline @click="logout">
            Sair
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
import AccessControlService from '@/api-services/access-control'
import StoreAuthConstants from '@/store/constants/auth'
import { mapGetters, mapActions } from 'vuex'
export default {
  computed: {
    ...mapGetters({
      dialog: StoreAuthConstants.GETTERS.SHOW_LOGOUT_MODAL
    })
  },
  methods: {
    ...mapActions({
      showModal: StoreAuthConstants.ACTIONS.SHOW_LOGOUT_MODAL
    }),
    logout () {
      this.showModal(false)
      AccessControlService.Unauth()
    },
    closeModal () {
      this.showModal(false)
    }
  }
}
</script>
