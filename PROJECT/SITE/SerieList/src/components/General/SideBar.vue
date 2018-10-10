<template>
  <v-list dense>
    <template v-for="item in general_menu">
      <v-layout v-if="item.heading" :key="item.heading" row align-center>
        <v-flex xs6>
          <v-subheader v-if="item.heading">
            {{ item.heading }}
          </v-subheader>
        </v-flex>
        <v-flex xs6 class="text-xs-center">
          <a href="#!" class="body-2 black--text">EDIT</a>
        </v-flex>
      </v-layout>
      <v-list-group
        v-else-if="item.children"
        v-model="item.model"
        :key="item.text"
        :prepend-icon="item.model ? item.icon : item['icon-alt']"
        append-icon="">
        <v-list-tile slot="activator">
          <v-list-tile-content>
            <v-list-tile-title>
              {{ item.text }}
            </v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
        <v-list-tile
          v-for="(child, i) in item.children"
          :key="i" :to="{name: child.route}" exact>
          <v-list-tile-action v-if="child.icon">
            <v-icon>{{ child.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>
              {{ child.text }}
            </v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list-group>
      <v-list-tile v-else :key="item.text" :to="{name: item.route}" exact>
        <v-list-tile-action>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title>
            {{ item.text }}
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>
    </template>
    <v-divider/>
    <template v-for="item in submenu">
      <v-layout v-if="item.heading" :key="item.heading" row align-center>
        <v-flex xs6>
          <v-subheader v-if="item.heading">
            {{ item.heading }}
          </v-subheader>
        </v-flex>
        <v-flex xs6 class="text-xs-center">
          <a href="#!" class="body-2 black--text">EDIT</a>
        </v-flex>
      </v-layout>
      <v-list-group
        v-else-if="item.children"
        v-model="item.model"
        :key="item.text"
        :prepend-icon="item.model ? item.icon : item['icon-alt']"
        append-icon="">
        <v-list-tile slot="activator">
          <v-list-tile-content>
            <v-list-tile-title>
              {{ item.text }}
            </v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
        <v-list-tile
          v-for="(child, i) in item.children"
          :key="i" :to="{name: child.route}" exact>
          <v-list-tile-action v-if="child.icon">
            <v-icon>{{ child.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>
              {{ child.text }}
            </v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list-group>
      <v-list-tile v-else :key="item.text" :to="{name: item.route}" exact>
        <v-list-tile-action>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title>
            {{ item.text }}
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>
    </template>
    <v-divider/>
    <template v-for="item in config_menu">
      <v-layout v-if="item.heading" :key="item.heading" row align-center>
        <v-flex xs6>
          <v-subheader v-if="item.heading">
            {{ item.heading }}
          </v-subheader>
        </v-flex>
        <v-flex xs6 class="text-xs-center">
          <a href="#!" class="body-2 black--text">EDIT</a>
        </v-flex>
      </v-layout>
      <v-list-group
        v-else-if="item.children"
        v-model="item.model"
        :key="item.text"
        :prepend-icon="item.model ? item.icon : item['icon-alt']"
        append-icon="">
        <v-list-tile slot="activator">
          <v-list-tile-content>
            <v-list-tile-title>
              {{ item.text }}
            </v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
        <v-list-tile
          v-for="(child, i) in item.children"
          :key="i" :to="{name: child.route}" exact>
          <v-list-tile-action v-if="child.icon">
            <v-icon>{{ child.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>
              {{ child.text }}
            </v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list-group>
      <v-list-tile v-else :key="item.text" :to="{name: item.route}" exact>
        <v-list-tile-action>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title>
            {{ item.text }}
          </v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>
    </template>
  </v-list>
</template>

<script>
export default {
  data: () => ({
    general_menu: [
      { icon: 'home', text: 'Início', route: 'home.index' },
      {
        icon: 'keyboard_arrow_up',
        'icon-alt': 'keyboard_arrow_down',
        text: 'Séries',
        model: false,
        children: [
          { icon: 'list', text: 'Listar', route: 'serie.all' },
          { icon: 'add', text: 'Adicionar', route: 'serie.add' }
        ]
      },
      {
        icon: 'keyboard_arrow_up',
        'icon-alt': 'keyboard_arrow_down',
        text: 'Animes',
        model: false,
        children: [
          { icon: 'list', text: 'Listar' },
          { icon: 'add', text: 'Adicionar' }
        ]
      },
      {
        icon: 'keyboard_arrow_up',
        'icon-alt': 'keyboard_arrow_down',
        text: 'Filmes',
        model: false,
        children: [
          { icon: 'list', text: 'Listar' },
          { icon: 'add', text: 'Adicionar' }
        ]
      }
    ],
    submenu: [
      {
        icon: 'keyboard_arrow_up',
        'icon-alt': 'keyboard_arrow_down',
        text: 'Temporadas',
        model: false,
        children: [
          { icon: 'list', text: 'Listar' },
          { icon: 'add', text: 'Adicionar' }
        ]
      },
      {
        icon: 'keyboard_arrow_up',
        'icon-alt': 'keyboard_arrow_down',
        text: 'Episódios',
        model: false,
        children: [
          { icon: 'list', text: 'Listar' },
          { icon: 'add', text: 'Adicionar' }
        ]
      }
    ],
    config_menu: [
      { icon: 'settings', text: 'Ajustes' },
      { icon: 'chat_bubble', text: 'Feedback' },
      { icon: 'help', text: 'Ajuda' }
    ]
  }),
  methods: {
    redirect (link) {
      this.$router.push({name: link})
    }
  }
}
</script>
