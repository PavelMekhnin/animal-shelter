import React from 'react';
import { IAnimalCard } from '../interfaces/Interfaces';
import { AnimalCardPreview } from './AnimalCardPreview';

type AnimalList = {
    list: IAnimalCard[]
}

export const AnimalCardList: React.FC<AnimalList> = ({ list }) => {
    if (list.length == 0) {
        return (<span>На настоящий момент у приюта нет питомцев :(</span>)
    }
    return (
        <div>
            {list.map(card => {
                return (
                    <div className="col s6">
                        <AnimalCardPreview card={card}></AnimalCardPreview>
                    </div>
                )
            })
            }
        </div>
    )
}