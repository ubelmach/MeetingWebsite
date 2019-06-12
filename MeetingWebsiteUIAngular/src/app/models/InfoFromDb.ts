import { Info } from 'src/app/models/Info';

export class InfoFromDb{
    constructor(
        Purposes: Info[] = new Array(),
        Languages: Info[] = new Array(),
        BadHabits: Info[] = new Array(),
        Interests: Info[] = new Array(),
        Education: Info[] = new Array(),
        Gender: Info[] = new Array(),
        Nationality: Info[] = new Array(),
        ZodiacSigns: Info[] = new Array(), 
        Finans: Info[] = new Array()
    ) {}
}