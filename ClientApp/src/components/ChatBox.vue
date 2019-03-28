<template>
  <transition-group class="chat-box" name="slide-up" appear>
    <div
      class="chat-message"
      v-for="message in messages"
      :key="message.timestamp"
    >
      {{ message.message }}<br>
      <i>{{ message.username }} @ {{ message.initiator }}</i>
    </div>
  </transition-group>
</template>

<script>
import * as signalR from '@aspnet/signalr';

export default {
  data() {
    return {
      messages: [],
    };
  },
  async mounted() {
    this.hub = new signalR.HubConnectionBuilder()
        .withUrl('/chat')
        .build();
    this.hub.on('ReceiveMessage', (message) => {
      this.messages.push(message);
      if (this.messages.length > 5) {
        this.messages.shift();
      }
    });
    await this.hub.start();
  },
};
</script>

<style scoped>
.chat-box {
  position: relative;
}

.chat-message {
  text-align: left;
  opacity: 1;
}

.chat-message > i {
  font-size: .8em;
}

.slide-up-enter-active, .slide-up-leave-active, .slide-up-move {
  transition: all .5s ease-in-out;
}

.slide-up-leave-active {
  position: absolute;
}

.slide-up-enter {
  transform: translateY(1em);
  opacity: 0;
}

.slide-up-leave-to {
  transform: translateY(-1em);
  opacity: 0;
}
</style>

