import React from "react";
import { Link } from "react-router-dom";
import { IAnimalCard } from "../interfaces/Interfaces";

type AnimalCardProps = {
    card: IAnimalCard,
    shelterId : string
}

export const AnimalCardPreview = (data: AnimalCardProps) => {
    const url = `/shelter/${data.shelterId}/pet/${data.card.id}`;
    return (
        <div className="animal-card">
            <div className="row">
                <div className="col s12">
                    <div className="card small">
                        <div className="card-image">
                            <img src={data.card.imgUrl} className="activator" />
                        </div>
                        <div className="card-content">
                            <span className="card-title grey-text text-darken-4">{data.card.name}</span>
                            <p><Link to={url}>More</Link></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}