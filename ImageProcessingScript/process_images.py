from PIL import Image, ImageOps
import os

def process_image(input_path, output_path):
    with Image.open(input_path) as img:
        # Find the bounding box of the non-transparent part of the image
        bbox = img.getbbox()
        
        if bbox:
            # Crop the image to the bounding box
            img_cropped = img.crop(bbox)
            
            # Optional: Resize the cropped image if you want to make it larger
            scale_factor = 1.5
            new_size = (int(img_cropped.width * scale_factor), int(img_cropped.height * scale_factor))
            img_cropped_resized = img_cropped.resize(new_size, Image.Resampling.LANCZOS)
            
            # Save the resized image
            img_cropped_resized.save(output_path, "PNG")
        else:
            # If the image is completely transparent, just save it as is
            img.save(output_path, "PNG")

input_folder = 'InputFolderPath'
output_folder = 'OutputFolderPath'

if not os.path.exists(output_folder):
    os.makedirs(output_folder)

for filename in os.listdir(input_folder):
    if filename.endswith(".png"):
        input_path = os.path.join(input_folder, filename)
        output_path = os.path.join(output_folder, filename)
        process_image(input_path, output_path)
