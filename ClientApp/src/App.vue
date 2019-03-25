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
          <h4>Intro til SIgnalR</h4>
          <li>Hva er SignalR?</li>
          <li>SignalR transports</li>
          <li>SignalR hubs</li>
          <li>SignalR clients &amp; groups</li>
          <li>Streaming data</li>
          <li>Connection lifecycle</li>
          <h4>Hands-on workshop</h4>
          <li>Vi bygger en egen liten SignalR app!</li>
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
          <li>Abstraksjon for realtime to-veis kommunikasjon</li>
          <li>Server i ASP.Net og klienter for js, c#, java, etc</li>
          <li>Innebygd støtte for horisontal skalering</li>
          <li>Automatisk nedgradering til eldre protokoller</li>
        </ul>
      </app-slide>

      <app-slide>
        <h1>SignalR transport</h1>
        <ul class="half">
          <li>
            Støtter 3 ulike protokoller:
            <ul>
              <li>WebSockets</li>
              <li>Server-Sent Events (SSE)</li>
              <li>Long Polling</li>
            </ul>
          </li>
          <li>Bruker automatisk den best støttede hos klient og server</li>
        </ul>
        <img class="half" src="./assets/data_center.svg"/>
      </app-slide>

      <app-slide>
        <h1>1-min intro til WebSockets</h1>
        <img class="half" src="./assets/data_process.svg"/>
        <ul class="half">
          <li>Støttet av alle nettlesere</li>
          <li>Oppretter to-veis kommunikasjon mellom klient og server</li>
          <li>Kommuniserer via frames over en TCP socket
            <ul>
              <li>Kan inspiseres i Chrome Devtools</li>
              <li>Firefox Devtools får støtte snart™</li>
            </ul>
          </li>
          <li>Forbindelse opprettes via HTTP, og støtter dermed:
            <ul>
              <li>CORS</li>
              <li>Cookies</li>
              <li>HTTP Headers</li>
            </ul>
          </li>
        </ul>
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
          <li>Tilgang til en kontekst som:
            <ul>
              <li>Fungerer som knutepunkt for mange klienter</li>
              <li>Lar deg kommunisere til alle klienter fra andre tjenester</li>
            </ul>
          </li>
        </ul>
      </app-slide>

      <app-slide>
        <h1>SignalR hubs</h1>
        <img src="./assets/signalR_hub_illustration.png" />
      </app-slide>

      <app-slide>
        <h1>SignalR hubs</h1>
        <img src="./assets/signalR_connection_illustration.png" />
      </app-slide>
      
      <app-slide>
        <h1>SignalR hub mapping</h1>
        <code-block :code="examples.HubMapping"/>
        <p>Startup.cs</p>
      </app-slide>

      <app-slide>
        <h1>SignalR hubs</h1>
        <code-block :code="examples.PingPongHub"/>
        <p>PingPongHub.cs</p>
      </app-slide>

      <app-slide>
        <h1>SignalR hubs</h1>
        <div class="half">
          <code-block :code="examples.PingPongHub"/>
          <p>PingPongHub.cs</p>
        </div>
        <div class="half">
          <code-block :code="examples.PingPongClient" lang="text/javascript"/>
          <p>PingPongClient.js</p>
          <span class="hint">Tilgjengelig på window.hubClients.pingpong</span>
        </div>
      </app-slide>

      <app-slide>
        <h1>SignalR hubs med DI</h1>
        <code-block :code="examples.DbContextHub"/>
        <p>DbContextHub.cs</p>
      </app-slide>

      <app-slide>
        <h1>SignalR hubs med sterkt typet klient</h1>
        <div class="half">
          <code-block :code="examples.TypedHub"/>
          <p>TypedHub.cs</p>
        </div>
        <div class="half">
          <code-block :code="examples.ITypedClient"/>
          <p>ITypedClient.cs</p>
        </div>
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
import * as signalR from '@aspnet/signalr';
import AppPresenter from './presenter';
import AppProgress from './components/AppProgress';
import AppViewers from './components/AppViewers';
import AppSlide from './components/AppSlide';
import CodeBlock from './components/CodeBlock';

import HubMapping from '!!raw-loader!./examples/HubMapping.cs';
import PingPongHub from '!!raw-loader!hubs/PingPongHub.cs';
import PingPongClient from '!!raw-loader!./examples/PingPongHubClient.js';
import DbContextHub from '!!raw-loader!./examples/DbContextHub.cs';
import TypedHub from '!!raw-loader!./examples/TypedHub.cs';
import ITypedClient from '!!raw-loader!./examples/ITypedClient.cs';

Vue.component('app-presenter', AppPresenter);

export default {
  name: 'app',
  components: {
    AppSlide,
    AppProgress,
    AppViewers,
    CodeBlock,
  },
  data() {
    return {
      progress: 0,
      examples: {
        HubMapping,
        PingPongHub,
        PingPongClient,
        DbContextHub,
        TypedHub,
        ITypedClient,
      }
    };
  },
  mounted() {
    // We want to register a number of global hub clients
    window.hubClients = {};

    const createClient = (name) => {
      const client = new signalR.HubConnectionBuilder()
        .withUrl(`/${name}`)
        .build();
      client.start();
      window.hubClients[name] = client;
    };

    createClient('pingpong');
    createClient('exceptions');
  },
  async beforeDestroy() {
    await window.hubClients.pingpong.stop();
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

.hint {
  font-style: italic;
  color: #374049;
  font-size: .9em;
  font-weight: 100;
  margin-top: .8em;
  display: block;
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
