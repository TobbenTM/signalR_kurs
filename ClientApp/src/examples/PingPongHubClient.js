import * as signalR from '@aspnet/signalr';

const client = new signalR.HubConnectionBuilder()
  .withUrl("/pingpong")
  .build();
await client.start();

const result = await client.invoke('Ping');
console.log(result);

await client.stop();