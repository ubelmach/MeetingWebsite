import { Component, OnInit } from '@angular/core';
import { SignalRService } from 'src/app/shared/signalR.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { Input } from '@angular/core';

@Component({
  selector: 'app-chat-details',
  templateUrl: './chat-details.component.html',
  styleUrls: ['./chat-details.component.css']
})
export class ChatDetailsComponent implements OnInit {

  @Input() userId: string;
  @Input() dialogId: number;

  constructor(private activateRoute: ActivatedRoute,
    public signalR: SignalRService,
    private router: Router) { }

  message = '';
  messages: string[] = [];

  ngOnInit() {
    this.signalR.startConnection();
    this.addSendListener();
    this.addSendMyselfListener();

    console.log(this.userId);
    console.log(this.dialogId);
  }

  addSendListener() {
    this.signalR.hubConnection.on('Send', (message: string) => {
      this.messages.push(message);
    });
  }

  addSendMyselfListener() {
    this.signalR.hubConnection.on('SendMyself', (message: string) => {
      this.messages.push(message);
    });
  }

  addNewDialogListener() {
    this.signalR.hubConnection.on('AddNewDialog', (message: string) => {
      this.messages.push(message);
    });
  }

  onSendMessage() {
    this.signalR.Send(this.message, this.userId, this.dialogId);
  }
}
