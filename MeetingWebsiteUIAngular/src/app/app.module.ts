import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { ProfileComponent } from './home/profile/profile.component';
import { SearchComponent } from './home/search/search.component';
import { NgxBootstrapSliderModule } from 'ngx-bootstrap-slider';
import { FriendComponent } from './home/friend/friend.component';
import { ListComponent } from './home/friend/list/list.component';
import { RequestComponent } from './home/friend/request/request.component';
import { UserProfileComponent } from './home/user-profile/user-profile.component';
import { BlackListComponent } from './home/friend/black-list/black-list.component';
import { AlbumComponent } from './home/album/album.component';
import { DetailsAlbumComponent } from './home/album/details-album/details-album.component';
import { LightboxModule } from 'ngx-lightbox';
import { ChatComponent } from './home/chat/chat.component';
import { ChatDetailsComponent } from './home/chat/chat-details/chat-details.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    ProfileComponent,
    SearchComponent,
    FriendComponent,
    ListComponent,
    RequestComponent,
    UserProfileComponent,
    BlackListComponent,
    AlbumComponent,
    DetailsAlbumComponent,
    ChatComponent,
    ChatDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    LightboxModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    FormsModule,
    NgxBootstrapSliderModule
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
