export interface IAnimalCard {
    name: string,
    race: string,
    bio: string,
    age: number,
    description: string,
    id: number
    img_url: string
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
    img_url: string,
    phone: string
}

export interface INeed {
    capture: string,
    count: number,
    description: string,
    id: number,
    isDone: boolean
}

export interface IShelterCard {
    title: string,
    description: string,
    addres: string,
    img_url: string,
    cover_url: string,
    id: number,
    animals: IAnimalCard[],
    volunteers: IVolunteerCard[],
    needs: INeed[],
    contacts: IContact[]
}

export interface IShelterCardPreview {
    id: number,
    title: string,
    addres: string,
    logo_url: string,
    animal_count: number,
    volunteer_count: number
}