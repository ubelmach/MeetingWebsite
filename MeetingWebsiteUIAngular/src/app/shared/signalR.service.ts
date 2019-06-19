import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { HttpTransportType } from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';


@Injectable({
    providedIn: 'root'
})

export class SignalRService {

    public hubConnection: HubConnection

    public startConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl('https://localhost:44333/chat',
                { 
                    skipNegotiation: true, 
                    transport: HttpTransportType.WebSockets,
                    accessTokenFactory: () => localStorage.getItem('token')
                })
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection: ' + err))
    }


    SendFromProfile(message: string, userId: string): void {
        this.hubConnection
            .invoke('SendFromProfile', message, userId)
            .catch(err => console.error(err));
    }
}