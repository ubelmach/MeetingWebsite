import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'https://localhost:44333/api';

  formModel = this.fb.group({
    FirstName: ['', Validators.required],
    LastName: ['', Validators.required],
    Email: ['', Validators.email],
    Birthday: ['', Validators.required],
    GenderId: ['', Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      PasswordConfirm: ['', Validators.required],
    }, { validator: this.comparePasswords })
  })

  editModel = this.fb.group({
    FirstName: [''],
    LastName: [''],
    Birthday: [''],
    Genders: [''],
    PurposeOfDating: [''],
    MaritalStatus: [''],
    Height: [''],
    Weight: [''],
    Education: [''],
    Nationality: [''],
    ZodiacSign: [''],
    KnowledgeOfLanguages: [''],
    BadHabits: [''],
    FinancialSituation: [''],
    Interests: [''],
    AnonymityMode: ['']
  })

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('PasswordConfirm');
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  register() {
    var body = {
      FirstName: this.formModel.value.FirstName,
      LastName: this.formModel.value.LastName,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Passwords.Password,
      Birthday: this.formModel.value.Birthday,
      GenderId: this.formModel.value.GenderId
    };
    return this.http.post(this.BaseURI + '/account/Register', body);
  }

  login(formData) {
    return this.http.post(this.BaseURI + '/account/Login', formData);
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/user/UserProfile');
  }

  getGenders() {
    return this.http.get(this.BaseURI + '/user/Genders');
  }

  getInfo(){
    return this.http.get(this.BaseURI + '/information/GetInfo')
  }

  updateUserProfile() {
    var body = {
      Firstname: this.editModel.value.FirstName,
      Lastname: this.editModel.value.LastName,
      Birthday: this.editModel.value.Birthday,
      Genders: this.editModel.value.Genders,
      PurposeOfDating: this.editModel.value.PurposeOfDating,
      MaritalStatus: this.editModel.value.MaritalStatus,
      Height: this.editModel.value.Height,
      Weight: this.editModel.value.Weight,
      Education: this.editModel.value.Education,
      Nationality: this.editModel.value.Nationality,
      ZodiacSign: this.editModel.value.ZodiacSign,
      KnowledgeOfLanguages: this.editModel.value.KnowledgeOfLanguages,
      BadHabits: this.editModel.value.BadHabits,
      FinancialSituation: this.editModel.value.FinancialSituation,
      Interests: this.editModel.value.Interests,
      AnonymityMode: this.editModel.value.AnonymityMode
    };
    return this.http.put(this.BaseURI + '/user/EditUserInformation', body)
  }

  postFile(fileToUpload: File) {
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload);
    return this.http.put(this.BaseURI + '/user/EditUserAvatar', formData);
  }
}
