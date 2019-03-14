<template>
  <div id="app">
    <app-presenter v-on:progress="progress = $event">

      <app-slide>
        <img src="./assets/swimlane-signalr-hub.svg" style="min-width: 25em;"/>
        <h1 class="signalr-title">SignalR</h1>
        <h4>Introduksjonskurs og workshop</h4>
        <a href="http://signalr.nærd.no" style="width: 100%;">signalr.nærd.no</a>
        <a href="https://github.com/tobbentm/signalR_kurs">github.com/tobbentm/signalR_kurs</a>
      </app-slide>

      <app-slide>
        <h1>Agenda:</h1>
        <ul>
          <li>Hva er SignalR?</li>
          <li>SignalR transports</li>
          <li>SignalR hubs</li>
          <li>SignalR clients &amp; groups</li>
        </ul>
      </app-slide>

      <app-slide>
        <h1>Hvem er jeg?</h1>
        <img src="http://tobbentm.com/ul/pl05.jpg" style="border-radius: 50%; overflow: hidden; max-width: 256px;" />
        <h4>Tobias Lønnerød Madsen</h4>
        <p>Fullstack utvikler .Net</p><br/>
        <a href="https://github.com/TobbenTM">github.com/TobbenTM</a>
      </app-slide>

      <app-slide>
        <h1>Hva er SignalR?</h1>
        <ul>
          <li>Abstraksjon for realtime kommunikasjon</li>
          <li>Server i ASP.Net og klienter for js, c#, java, etc</li>
          <li>Innebygd støtte for horisontal skalering</li>
          <li>Automatisk nedgradering til eldre protokoller</li>
        </ul>
      </app-slide>

      <app-slide>
        <h1>SignalR transport</h1>

      </app-slide>

      <app-slide>
        <h1>SignalR hubs</h1>
        <ul>
          <li>Veldig like kontrollere
            <ul>
              <li>Dependency Injection på samme måte</li>
              <li>Mapping på omtrent samme måte</li>
              <li>Kjempeenkle å sette opp!</li>
            </ul>
          </li>
          <li>Fungerer som knutepunkt for mange klienter</li>
        </ul>
      </app-slide>

      <app-slide>
        <img src="./assets/power_of_sharing.png" />
      </app-slide>

    </app-presenter>
    <app-progress :progress="progress"/>
    <app-viewers/>
  </div>
</template>

<script>
import Vue from 'vue';
import AppPresenter from './presenter';
import AppProgress from './components/AppProgress';
import AppViewers from './components/AppViewers';
import AppSlide from './components/AppSlide';
// import CodeBlock from './components/CodeBlock';
// import VerticalImage from './components/VerticalImage';

Vue.component('app-presenter', AppPresenter);

export default {
  name: 'app',
  components: {
    AppSlide,
    AppProgress,
    AppViewers,
    // CodeBlock,
    // VerticalImage,
  },
  data() {
    return {
      progress: 0,
      examples: {
      }
    };
  },
};
</script>

<style>
html, body {
  padding: 0;
  margin: 0;
  height: 100%;
  overflow: hidden;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100%;
  font-size: 1.5em;
}

.signalr-title {
  font-family: 'Segoe UI', 'Avenir', Helvetica, Arial, sans-serif;
  font-weight: 400;
  font-size: 2.8em;
}

.slide-left-enter-active, .slide-left-leave-active,
.slide-right-enter-active, .slide-right-leave-active {
  transition: all .5s ease-in-out;
}

.slide-left-enter, .slide-left-leave-to,
.slide-right-enter, .slide-right-leave-to {
  opacity: 0;
}

.slide-left-enter, .slide-right-leave-to {
  transform: translateX(-75px);
}

.slide-right-enter, .slide-left-leave-to {
  transform: translateX(75px);
}
</style>
