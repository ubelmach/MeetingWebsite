import { Component, OnInit } from '@angular/core';
import { FriendService } from 'src/app/shared/friend.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {

  constructor(public service: FriendService,
    private toastr: ToastrService) { }

 newRequest;

 ngOnInit() {
   this.service.getNewRequest().subscribe(
     res => {
       this.newRequest = res;
     }
   )
 }

 onAccept(id: number){
   this.service.AcceptNewRequest(id).subscribe(
     (res : any) => {
       this.ngOnInit();
       this.toastr.success('Success!', 'User added to your friends list.');
     },
     err => {
       console.log(err);
     }
   )
 }

 onReject(id: number){
   this.service.RejectNewRequest(id).subscribe(
     (res: any) => {
       this.ngOnInit();
       this.toastr.success('Success!', 'User request is displayed in the tab "Outgoing".');
     }
   )
 }
}
