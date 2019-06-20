import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './home/profile/profile.component';
import { AuthGuard } from './auth/auth.guard';
import { SearchComponent } from './home/search/search.component';
import { FriendComponent } from './home/friend/friend.component';
import { ListComponent } from './home/friend/list/list.component';
import { RequestComponent } from './home/friend/request/request.component';
import { UserProfileComponent } from './home/user-profile/user-profile.component';
import { BlackListComponent } from './home/friend/black-list/black-list.component';
import { AlbumComponent } from './home/album/album.component';
import { DetailsAlbumComponent } from './home/album/details-album/details-album.component';
import { ChatComponent } from './home/chat/chat.component';
import { ChatDetailsComponent } from './home/chat/chat-details/chat-details.component';


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
          { path: 'request', component: RequestComponent },
          { path: 'black-list', component: BlackListComponent }
        ]
      },
      {
        path: 'user-profile/:id', component: UserProfileComponent
      },
      {
        path: 'search', component: SearchComponent
      },
      {
        path: 'album', component: AlbumComponent,
        children: [
          { path: 'details-album/:id', component: DetailsAlbumComponent }
        ]
      },
      {
        path: 'chat', component: ChatComponent,
        children: [
          // { path: 'chat-details/:id', component: ChatDetailsComponent }
          { path: 'chat-details/', component: ChatDetailsComponent }
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
