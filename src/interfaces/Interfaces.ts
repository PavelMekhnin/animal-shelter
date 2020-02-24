export interface IAnimalCard {
    name: string,
    description: string,
    bio: string,
    id: number
    img_url: string
}

export interface IVolunteerCard {
    firstName : string,
    lastName : string,
    id : number,
    img_url : string,
    phone : string
}

export interface IAnimalNeed {
    capture : string,
    count: number,
    description : string,
    id: number,
    isDone : boolean
}