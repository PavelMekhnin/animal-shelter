import React from 'react';
import { IAnimalCard } from '../interfaces/Interfaces';
import { AnimalCardPreview } from './AnimalCardPreview';
import { Link } from 'react-router-dom';

type AnimalList = {
    list: IAnimalCard[],
    shelterId: string
}

export const AnimalCardList = (data: AnimalList) => {
    var exists = data.list != null && data.list.length > 0;
    var link = `/shelter/${data.shelterId}/pets`
    return (
        <>
            <div className="shelter-profile_tabs_tab">
                <div className="row">
                    <h5 className="center-align orange-text">Our animals</h5>
                </div>
                <div className="row">
                    {exists ?
                        (data.list.slice(0, 6).map(card => {
                            return (
                                <div className="col s6 m6 l4" key={card.id}>
                                    <AnimalCardPreview card={card} shelterId={data.shelterId} key={card.id}></AnimalCardPreview>
                                </div>
                            )
                        })

                        )
                        :
                        <p>We do not have any animals yet ;(</p>
                    }
                </div>
                <div className="row">
                    {exists && <Link to={link} >More</Link>}
                </div>
            </div>
        </>
    )
}