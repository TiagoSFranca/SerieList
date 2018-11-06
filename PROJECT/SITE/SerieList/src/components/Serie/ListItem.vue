<template>
  <v-layout row>
    <v-flex xs12 sm12>
      <v-card color="red accent-1" v-if="product.Excluded">
        <product-item :product="product"/>
      </v-card>
      <v-card v-else>
        <product-item :product="product"/>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import StoreAuthConstants from '@/store/constants/auth'
import ProductItem from '@/components/serie/Item'
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
  components: {
    ProductItem
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
