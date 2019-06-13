import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './home/profile/profile.component';
import { AuthGuard } from './auth/auth.guard';
import { SearchComponent } from './home/search/search.component';
import { InfoComponent } from './home/search/info/info.component';
import { FriendComponent } from './home/friend/friend.component';
import { ListComponent } from './home/friend/list/list.component';
import { IncomingComponent } from './home/friend/incoming/incoming.component';
import { OutgoingComponent } from './home/friend/outgoing/outgoing.component';


const routes: Routes = [
  {
    path: '', redirectTo: "/user/login", pathMatch: 'full'
  },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  {
    path: 'home', component: HomeComponent, canActivate: [AuthGuard],
    children: [
      {
        path: 'profile', component: ProfileComponent
      },
      {
        path: 'friend', component: FriendComponent,
        children: [
          { path: 'list', component: ListComponent },
          { path: 'incoming', component: IncomingComponent },
          { path: 'outgoing', component: OutgoingComponent }
        ]
      },
      {
        path: 'search', component: SearchComponent,
        children: [
          {
            path: 'info/:id', component: InfoComponent
          }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
