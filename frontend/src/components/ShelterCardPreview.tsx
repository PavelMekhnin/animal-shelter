import React from "react";
import { Link } from "react-router-dom";
import { IShelterCardPreview } from "../interfaces/Interfaces";

type ShelterCardProps = {
    card: IShelterCardPreview
}

export const ShelterCardPreview: React.FC<ShelterCardProps> = (card) => {
    const url = `/shelter/${card.card.id}`
    return (
        <div className="col s12">
            <div className="card-panel grey lighten-5 z-depth-1">
                <Link to={url}>
                    <div className="row valign-wrapper">
                        <div className="col s2">
                            <img src={card.card.logoUrl} alt="" className="circle responsive-img" />
                        </div>
                        <div className="col s10">
                            <span className="black-text">
                                {card.card.title}, Address: {card.card.address}
                            </span>
                        </div>
                    </div>
                </Link>
            </div>
        </div>
    )
}