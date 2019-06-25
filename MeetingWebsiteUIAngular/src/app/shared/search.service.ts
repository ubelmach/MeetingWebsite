import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class SearchService {
    constructor(private fb: FormBuilder, private http: HttpClient) { }
    readonly BaseURI = 'https://localhost:44333/api';

    searchModel = this.fb.group({
        AgeFrom: [''],
        AgeTo: [''],
        HeightFrom: [''],
        HeightTo: [''],
        WeightFrom: [''],
        WeightTo: [''],
        Genders: [''],
        PurposeOfDating: [Array],
        Education: [Array],
        Nationality: [Array],
        ZodiacSign: [Array],
        KnowledgeOfLanguages: [Array],
        BadHabits: [Array],
        FinancialSituation: [Array],
        Interests: [Array]
    })

    getInfo() {
        return this.http.get(this.BaseURI + '/information/GetInfo');
    }

    searchUsers(){
        debugger;
        var body = {
            AgeFrom: this.searchModel.value.AgeFrom,
            AgeTo: this.searchModel.value.AgeTo,
            HeightFrom: this.searchModel.value.HeightFrom,
            HeightTo: this.searchModel.value.HeightTo,
            WeightFrom: this.searchModel.value.WeightFrom,
            WeightTo: this.searchModel.value.WeightTo,
            Genders: this.searchModel.value.Genders,
            PurposeOfDating: this.searchModel.value.PurposeOfDating,
            Education: this.searchModel.value.Education,
            Nationality: this.searchModel.value.Nationality,
            ZodiacSign: this.searchModel.value.ZodiacSign,
            KnowledgeOfLanguages: this.searchModel.value.KnowledgeOfLanguages,
            BadHabits: this.searchModel.value.BadHabits,
            FinancialSituation: this.searchModel.value.FinancialSituation,
            Interests: this.searchModel.value.Interests
        }
        return this.http.post(this.BaseURI + '/search/SearchUsersByCriteria', body);
    }

    getSearchUserDetails(userId: string){
        return this.http.get(this.BaseURI + '/friend/FriendInfo/' + userId);
    }

    sendRequestUser(userId: string){
        return this.http.get(this.BaseURI + '/friend/NewRequest/' + userId);
    }

    AddToBlackList(userId: string){
        return this.http.get(this.BaseURI + '/blacklist/AddUserInBlackList/' + userId);
    }
}