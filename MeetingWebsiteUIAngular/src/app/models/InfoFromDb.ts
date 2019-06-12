import { Info } from 'src/app/models/Info';

export class InfoFromDb{
    constructor(
        Purposes: Info[],
        Languages: Info[],
        BadHabits: Info[],
        Interests: Info[],
        Education: Info[],
        Gender: Info[] = new Array(),
        Nationality: Info[],
        ZodiacSigns: Info[], 
        Finans: Info[]
    ) {}
}