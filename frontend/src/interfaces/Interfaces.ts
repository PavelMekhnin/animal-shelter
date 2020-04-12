export interface IAnimalCard {
    name: string,
    race: string,
    bio: string,
    age: number,
    description: string,
    id: number
    imgUrl: string
    needs: INeed[],
    volunteers: IVolunteerCard[]
}

export interface IContact {
    type: string,
    value: string,
    owner: string
}

export interface IVolunteerCard {
    firstName: string,
    lastName: string,
    id: number,
    imgUrl: string,
    phone: string
}

export interface INeed {
    title: string,
    count: number,
    description: string,
    id: number,
    isDone: boolean
}

export interface IShelterCard {
    title: string,
    description: string,
    address: string,
    logoUrl: string,
    coverUrl: string,
    id: number,
    animals: IAnimalCard[],
    volunteers: IVolunteerCard[],
    needs: INeed[],
    contacts: IContact[]
}

export interface IShelterCardPreview {
    id: number,
    title: string,
    address: string,
    logoUrl: string,
    animalCount: number,
    volunteerCount: number
}