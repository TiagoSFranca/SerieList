<template>
    <v-flex xs12 sm12 md12 >
        <v-container fluid grid-list-sm>
            <v-layout row wrap>
                <v-flex xs6 offset-xs3>
                    <v-card class="elevation-10">
                        <v-toolbar dark color="primary">
                            <v-toolbar-title>Adicionar Série</v-toolbar-title>
                            <v-spacer></v-spacer>
                            <v-toolbar-items>
                            <v-btn flat class="elevation-10" :to="{name: returnUrl}">Voltar</v-btn>
                            </v-toolbar-items>
                        </v-toolbar>
                        <v-card-text>
                            <v-form ref="form" v-model="valid" lazy-validation>
                                <v-layout row wrap>
                                    <v-flex xs12>
                                        <v-text-field
                                        v-model="title" :rules="titleRules"
                                        :counter="128" label="Título" required/>
                                    </v-flex>
                                    <v-flex xs6>
                                        <v-select
                                        v-model="idProductStatus"
                                        item-text="Description"
                                        item-value="IdProductStatus"
                                        :items="productStatusResult.Items"
                                        :rules="[v => !!v || generalMessage]"
                                        label="Situação da série"
                                        required/>
                                    </v-flex>
                                    <v-flex xs6>
                                        <v-select
                                        v-model="idVisibility"
                                        item-text="Description"
                                        item-value="IdVisibility"
                                        :items="visibilityResult.Items"
                                        :rules="[v => !!v || generalMessage]"
                                        label="Visibilidade"
                                        required/>
                                    </v-flex>
                                    <v-flex xs12>
                                        <v-textarea name="description" label="Descrição"
                                        value="" :counter="512" :rules="descriptionRules"/>
                                    </v-flex>
                                    <v-flex xs6>
                                        <v-menu v-model="menuBeginAt" :close-on-content-click="false" full-width max-width="290">
                                        <v-text-field
                                            slot="activator"
                                            :value="computedBeginAt"
                                            clearable
                                            label="Começa em"
                                            readonly
                                        ></v-text-field>
                                        <v-date-picker
                                            v-model="beginAt"
                                            @change="menuBeginAt = false"
                                            locale="pt-br"
                                        ></v-date-picker>
                                        </v-menu>
                                    </v-flex>
                                    <v-flex xs6>
                                        <v-menu v-model="menuEndAt" :close-on-content-click="false" full-width max-width="290">
                                        <v-text-field
                                            slot="activator"
                                            :value="computedEndAt"
                                            clearable
                                            label="Termina em"
                                            readonly
                                        ></v-text-field>
                                        <v-date-picker
                                            v-model="endAt"
                                            @change="menuEndAt = false"
                                            locale="pt-br"
                                        ></v-date-picker>
                                        </v-menu>
                                    </v-flex>
                                </v-layout>
                            </v-form>
                        </v-card-text>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn :disabled="!valid" @click="submit" round color="success" class="elevation-10">
                            Adicionar
                            </v-btn>
                            <v-btn @click="clear" round color="info" class="elevation-10">Limpar</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
    </v-flex>
</template>

<script>
import ProductStatusService from '@/api-services/product-status'
import StoreProductStatusConstants from '@/store/constants/product-status'
import VisibilityService from '@/api-services/visibility'
import StoreVisibilityConstants from '@/store/constants/visibility'
import SerieService from '@/api-services/serie'
import GeneralMessages from '@/helpers/general-messages'
import Formatters from '@/helpers/formatters'
import { mapGetters } from 'vuex'

export default {
  data: () => ({
    valid: true,
    title: '',
    titleRules: [
      v => !!v || GeneralMessages.required,
      v => (v && v.length <= 128) || GeneralMessages.maxLengthError
    ],
    descriptionRules: [
      v => (v && v.length <= 512) || GeneralMessages.maxLengthError
    ],
    idProductStatus: null,
    idVisibility: null,
    generalMessage: GeneralMessages.required,
    beginAt: null,
    menuBeginAt: false,
    endAt: null,
    menuEndAt: false,
    returnUrl: 'home'
  }),
  methods: {
    submit () {
      if (this.$refs.form.validate()) {
        let obj = {
          IdProductStatus: this.idProductStatus,
          IdVisibility: this.idVisibility,
          Title: this.title,
          Description: this.Description,
          BeginAt: this.beginAt,
          EndAt: this.endAt
        }
        SerieService.add(obj)
      }
    },
    clear () {
      this.$refs.form.reset()
    }
  },
  created () {
    ProductStatusService.search({excluded: false})
    VisibilityService.search({excluded: false})
  },
  computed: {
    ...mapGetters({
      productStatusResult: StoreProductStatusConstants.GETTERS.GET_RESULT,
      visibilityResult: StoreVisibilityConstants.GETTERS.GET_RESULT
    }),
    computedBeginAt () {
      return Formatters.FormatDate(this.beginAt)
    },
    computedEndAt () {
      return Formatters.FormatDate(this.endAt)
    }
  }
}
</script>
