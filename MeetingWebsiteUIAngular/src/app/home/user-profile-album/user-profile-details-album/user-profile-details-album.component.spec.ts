import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProfileDetailsAlbumComponent } from './user-profile-details-album.component';

describe('UserProfileDetailsAlbumComponent', () => {
  let component: UserProfileDetailsAlbumComponent;
  let fixture: ComponentFixture<UserProfileDetailsAlbumComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserProfileDetailsAlbumComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserProfileDetailsAlbumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
