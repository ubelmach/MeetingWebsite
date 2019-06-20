import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { HttpTransportType } from '@aspnet/signalr';
import { stringify } from '@angular/core/src/util';


@Injectable({
    providedIn: 'root'
})

export class SignalRService {

    public hubConnection: signalR.HubConnection
    private token = localStorage.getItem('token');

    constructor() { }

    public startConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl('https://localhost:44333/chat',
                { 
                    skipNegotiation: true, 
                    transport: HttpTransportType.WebSockets,
                    accessTokenFactory: () => this.token
                })
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection: ' + err))
    }


    Send(message: string, userId: string, dialogId: number) : void{
        this.hubConnection
        .invoke('Send', message, userId, dialogId)
        .catch(err => console.error(err));
    }       
    
    SendFromProfile(message: string, userId: string): void {
        this.hubConnection
            .invoke('SendFromProfile', message, userId)
            .catch(err => console.error(err)); 
    }
}