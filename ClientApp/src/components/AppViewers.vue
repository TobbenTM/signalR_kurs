<template>
  <div class="viewers">
    <transition-group name="viewers__list">
      <span
        v-for="viewer in viewers"
        :key="viewer"
        class="viewers__list__item"
      >
        😍
      </span>
    </transition-group>
  </div>
</template>

<script>
import * as signalR from '@aspnet/signalr';

export default {
  data() {
    return {
      viewers: [],
    };
  },
  async mounted() {
    // Create the hub
    this.hub = new signalR.HubConnectionBuilder()
      .withUrl("/viewers")
      .build();

    // Register method listeners
    this.hub.on('ViewersUpdated', viewers => this.viewers = viewers);

    // Connect to the hub
    // (Should be done after registering listeners)
    await this.hub.start();

    // Invoke method and get return value
    this.viewers = await this.hub.invoke('Join');
  },
};
</script>

<style lang="scss" scoped>
.viewers {
  height: 100%;
  width: 2em;
  position: absolute;
  display: flex;
  right: 0;
  top: 0;
  justify-content: center;
  align-items: center;

  &__list {
    &__item {
      transition: all 1s;
      display: block;
      margin-bottom: 10px;
    }

    &-enter, &-leave-to {
      opacity: 0;
      transform: translateX(-30px);
    }

    &-leave-active {
      position: absolute;
    }
  }
}
</style>
