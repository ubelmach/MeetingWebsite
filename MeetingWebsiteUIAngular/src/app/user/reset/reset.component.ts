import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reset',
  templateUrl: './reset.component.html',
  styleUrls: ['./reset.component.css']
})
export class ResetComponent implements OnInit {

  constructor(public service: UserService, 
    private toastr: ToastrService,
    private activateRoute: ActivatedRoute,
    private router: Router,) { }

    code: string;

  async ngOnInit() {
    await this.activateRoute.params.subscribe(
      params => this.code = params.code);
  }
  onSubmit() {
    this.service.reset(this.code).subscribe(
      (res: any) => {
          this.service.resetModel.reset();
          this.router.navigateByUrl('user/login');
          this.toastr.success('Success!')
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Faild!');
        else
          console.log(err);
      }
    )
  }

}
