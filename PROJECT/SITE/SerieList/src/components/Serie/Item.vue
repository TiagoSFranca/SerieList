<template>
    <div>
        <v-img src="https://cdn.vuetifyjs.com/images/cards/desert.jpg" aspect-ratio="2.75"/>
        <v-card-title primary-title>
          <div>
            <div class="headline">{{product.ProductInfo.Title}}</div>
          </div>
        </v-card-title>
        <v-card-actions>
            <v-tooltip bottom>
                <v-btn flat icon slot="activator" color="blue" v-show="!IsUserProduct()">
                    <v-icon>person</v-icon>
                </v-btn>
                <span>{{product.User.UserInfo.FirstName}}</span>
            </v-tooltip>
            <v-spacer></v-spacer>
            <v-btn flat icon v-if="IsUserProduct()" color="red">
            <v-icon>favorite</v-icon>
            </v-btn>
            <v-btn flat icon v-else>
            <v-icon>favorite_border</v-icon>
            </v-btn>
            <v-btn icon flat v-show="IsUserProduct()">
            <v-icon>delete</v-icon>
            </v-btn>
        </v-card-actions>
        <v-card-actions>
            <v-rating v-model="product.IdProduct"
            :hover="true"
            :readonly="true"
            ></v-rating>
        </v-card-actions>
        <v-card-actions>
          <v-btn flat>Visualizar</v-btn>
          <v-btn flat color="purple">Editar</v-btn>
          <v-spacer></v-spacer>
          <v-btn icon @click="show = !show">
            <v-icon>{{ show ? 'keyboard_arrow_down' : 'keyboard_arrow_up' }}</v-icon>
          </v-btn>
        </v-card-actions>
        <v-slide-y-transition>
          <v-card-text v-show="show">
            {{product.ProductInfo.Description}}
          </v-card-text>
        </v-slide-y-transition>
    </div>
</template>

<script>
import StoreAuthConstants from '@/store/constants/auth'
import { mapGetters } from 'vuex'
export default {
  props: ['product'],
  data: () => ({
    show: false
  }),
  methods: {
    IsUserProduct () {
      return this.userData.IdUser === this.product.IdUser
    }
  },
  computed: {
    ...mapGetters({
      userData: StoreAuthConstants.GETTERS.USER_DATA
    })
  },
  created () {
    this.IsUserProduct()
  }
}
</script>
