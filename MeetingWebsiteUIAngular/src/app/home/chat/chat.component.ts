import { Component, OnInit } from '@angular/core';
import { SignalRService } from 'src/app/shared/signalR.service';
import { ChatService } from 'src/app/shared/char.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  userList;
  visibleChatDetails = true;

  constructor(public signalR: SignalRService,
    public service: ChatService,
    private router: Router) { }

  ngOnInit() {
    this.signalR.startConnection();

    this.service.getUserDialogs().subscribe(
      res => {
        this.userList = res;
      },
      err => {
        console.log(err);
      }
    );
  }

  // onOpenDialog(id: number) {
    onOpenDialog() {
    this.visibleChatDetails = !this.visibleChatDetails;
    
    //this.router.navigateByUrl('/home/chat/chat-details/' + id.toString());
  }

}
