import { IShelterCard } from "../interfaces/Interfaces";

type ShelterReducerType = {
    shelters: IShelterCard[]
}

const initState = {
    shelters: [{
        address: 'Клин, Московская обл.',
        cover_url: 'https://sun9-52.userapi.com/c850016/v850016567/1bc460/ubjbr2z4hc4.jpg',
        description: 'приют для лоашдей',
        id: 1,
        title: 'Шанс на жизнь',
        img_url: 'https://sun9-7.userapi.com/c852016/v852016218/18ef1f/Ne6MaHZrJaA.jpg',
        animals: [{
            bio: 'bio',
            img_url: 'https://3.404content.com/1/CD/21/1202057187605349659/fullsize.jpg',
            description: 'description',
            age: 15,
            id: 1,
            name: 'Лёлик',
            race: 'дворняжка',
            needs: [
                { id: 1, title: 'лекарства', description: 'desc', isDone: false, count: 10 },
                { id: 2, title: 'подкормка', description: 'desc', isDone: false, count: 2 },
                { id: 3, title: 'сено', description: 'desc', isDone: false, count: 1 },
            ],
            volunteers: [{
                firstName: "Pavel",
                lastName: "Mekhnin",
                id: 1,
                img_url: "",
                phone: "+7 (913) 715 67 48"
            }]
        }],
        needs: [{ id: 1, title: 'лекарства', description: 'desc', isDone: false, count: 10 },
        { id: 2, title: 'подкормка', description: 'desc', isDone: false, count: 2 },
        { id: 3, title: 'сено', description: 'desc', isDone: false, count: 1 },],
        volunteers: [],
        contacts: []
    }]
}

export const shelterReduces = (state: ShelterReducerType = initState, action: any) => {
    switch (action.type) {


        default:
            return state;
            break;
    }
}