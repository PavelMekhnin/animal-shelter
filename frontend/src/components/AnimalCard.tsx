import React from "react";
import { VolunteerCardPreview } from "./VolunteerCardPreview";
import { IVolunteerCard, IAnimalCard } from "../interfaces/Interfaces";
import { useState } from "react";
import { VolunteerCardList } from "./VolunteerCardList";
import { AnimalNeeds } from "./AnimalNeeds";

export const AnimalCard: React.FC = () => {

    const card: IAnimalCard = {
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
    }

    return (
        <div className="container">
            <div className="row">
                <div className="col s3 grey lighten-5 center-align profile-left">
                    <div className="row">
                        <img className="responsive-img" src={card.img_url} />
                    </div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Имя</span>
                            <h6>{card.name}</h6>
                        </div>
                    </div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Возраст</span>
                            <h6>{card.age} лет</h6>
                        </div>
                    </div>
                    <div className="row">
                        <div className="left-info-block">
                            <span>Порода</span>
                            <h6>{card.race}</h6>
                        </div>
                    </div>
                </div>
                <div className="col s9">

                    <div className="row">
                        <h5>О питомце</h5>
                        <p>{card.bio}</p>
                    </div>
                    <div className="row">
                        <h5>Кураторы</h5>
                        <VolunteerCardList list={card.volunteers} />
                    </div>
                    <div className="row">
                        <h5>Нужды</h5>
                        <AnimalNeeds list={card.needs}></AnimalNeeds>
                    </div>
                </div>
            </div>
        </div>
    )
}