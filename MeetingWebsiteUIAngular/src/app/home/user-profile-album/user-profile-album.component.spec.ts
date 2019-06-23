import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProfileAlbumComponent } from './user-profile-album.component';

describe('UserProfileAlbumComponent', () => {
  let component: UserProfileAlbumComponent;
  let fixture: ComponentFixture<UserProfileAlbumComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserProfileAlbumComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserProfileAlbumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
