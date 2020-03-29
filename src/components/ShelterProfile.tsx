import React from "react";
import { AnimalCardPreview } from "./AnimalCardPreview";
import { IAnimalCard, IShelterCard } from "../interfaces/Interfaces";
import { AnimalCardList } from "./AnimalCardList";
import { ContactsBlock } from "./ContactsBlock";
import { AnimalNeeds } from "./AnimalNeeds";

export const ShelterProfile: React.FC = () => {
    const profile: IShelterCard = {
        addres: 'Клин, Московская обл.',
        cover_url: 'https://sun9-52.userapi.com/c850016/v850016567/1bc460/ubjbr2z4hc4.jpg',
        description: 'приют для лоашдей',
        id: 1,
        title: 'Шанс на жизнь',
        img_url: 'https://sun9-7.userapi.com/c852016/v852016218/18ef1f/Ne6MaHZrJaA.jpg',
        animals: [{
            name: "Огонек",
            bio: "",
            age: 15,
            description: "Один из самых старейших коней в возрасте 40 лет живет на пенсии в нашем приюте.",
            id: 1,
            img_url: "https://images.theconversation.com/files/250401/original/file-20181213-110249-1czg7z.jpg",
            needs: [],
            race: 'дворняжка',
            volunteers: []
        }],
        needs: [{ id: 1, capture: 'лекарства', description: 'desc', isDone: false, count: 10 },
        { id: 2, capture: 'подкормка', description: 'desc', isDone: false, count: 2 },
        { id: 3, capture: 'сено', description: 'desc', isDone: false, count: 1 },],
        volunteers: [],
        contacts: []
    }

    return (
        <div className="container">
            <div className="row">
                <div className="cover-img" style={{ backgroundImage: "url(" + profile.cover_url + ")" }}></div>
            </div>
            <div className="row">
                <div className="col s3 grey lighten-5 center-align">
                    <img className="circle logo-img z-depth-2" src={profile.img_url} alt="" />
                    <div className="row"><h5>{profile.title}</h5></div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Адрес</span>
                            <h6>{profile.addres}</h6>
                        </div>
                    </div>
                    <div className="row"><ContactsBlock list={profile.contacts}></ContactsBlock></div>
                </div>

                <div className="col s9">
                    <div className="row">
                        <h5>О нас</h5>
                        <p>{profile.description}</p>
                    </div>
                    <div className="row">
                        <h5>Питомцы</h5>
                        <AnimalCardList list={profile.animals}></AnimalCardList>
                    </div>
                    <div className="row">
                        <h5>Нужды</h5>
                        <AnimalNeeds list={profile.needs}></AnimalNeeds>
                    </div>
                </div>
            </div>
        </div>
    )
}