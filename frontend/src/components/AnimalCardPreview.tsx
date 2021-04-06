import React from "react";
import { Link } from "react-router-dom";
import { IAnimalCard } from "../interfaces/Interfaces";

type AnimalCardProps = {
    card: IAnimalCard,
    shelterId: string
}

export const AnimalCardPreview = (data: AnimalCardProps) => {
    const url = `/shelter/${data.shelterId}/pet/${data.card.id}`;
    return (
        <div className="animal-card">
            <div className="row">
                <div className="col s12">
                    <div className="card">
                        <div className="card-image">
                            <img src={data.card.imgUrl} className="activator" alt={data.card.description}/>
                            <span className="card-title">{data.card.name}</span>
                        </div>
                        <div className="card-action">
                            <Link to={url}>More</Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}